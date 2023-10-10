using LamilaDinner.Domain.DinnerAggregate.ValueObjects;
using LamilaDinner.Domain.HostAggregate.ValueObjects;
using LamilaDinner.Domain.MenuAggregate;
using LamilaDinner.Domain.MenuAggregate.Entities;
using LamilaDinner.Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LamilaDinner.Infrastructure.Persistence.Configurations;

public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenuSectionsTable(builder);
        ConfigureMenuDinnerIdsTable(builder);
        ConfigureMenuReviewIdsTable(builder);
    }

    private static void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuId.Create(value));

        builder.Property(m => m.Name).HasMaxLength(100);

        builder.Property(m => m.Description)
            .HasMaxLength(100);

        builder.OwnsOne(m => m.AverageRating);

        builder.Property(m => m.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));

        builder.HasIndex(m => m.Name);
    }

    private static void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.Sections, sb =>
        {
            sb.ToTable("MenuSections");

            sb.WithOwner().HasForeignKey(nameof(MenuId));

            sb.HasKey(nameof(Menu.Id), nameof(MenuId));

            sb.Property(s => s.Id)
                .HasColumnName(nameof(MenuSectionId))
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuSectionId.Create(value));

            sb.Property(s => s.Name).HasMaxLength(100);

            sb.Property(s => s.Description).HasMaxLength(100);

            sb.OwnsMany(s => s.Items, ib =>
            {
                ib.ToTable("MenuItems");

                ib.WithOwner().HasForeignKey(nameof(MenuSectionId), nameof(MenuId));

                ib.HasKey(nameof(MenuItem.Id), nameof(MenuSectionId), nameof(MenuId));

                ib.Property(i => i.Id)
                    .HasColumnName(nameof(MenuItemId))
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => MenuItemId.Create(value));

                ib.Property(s => s.Name).HasMaxLength(100);

                ib.Property(s => s.Description)
                    .HasMaxLength(100);
            });

            sb.Navigation(s => s.Items).Metadata.SetField("_items");

            sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
        });

        builder.Metadata.FindNavigation(nameof(Menu.Sections))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.DinnerIds, dib =>
        {
            dib.ToTable("MenuDinnerIds");

            dib.WithOwner().HasForeignKey(nameof(MenuId));

            dib.HasKey(nameof(Menu.Id));

            dib.Property(d => d.Value)
                .HasColumnName(nameof(DinnerId))
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation("DinnerIds")!.SetPropertyAccessMode(PropertyAccessMode.PreferField);
    }

    private static void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.MenuReviewIds, dib =>
               {
                   dib.ToTable("MenuReviewIds");

                   dib.WithOwner().HasForeignKey(nameof(MenuId));

                   dib.HasKey(nameof(Menu.Id));

                   dib.Property(d => d.Value)
                       .HasColumnName("ReviewId")
                       .ValueGeneratedNever();
               });

        builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }

}
