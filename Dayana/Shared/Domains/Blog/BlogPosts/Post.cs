﻿using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Domains.Identity.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Dayana.Shared.Domains.Blog.Comments;

namespace Dayana.Shared.Domains.Blog.BlogPosts;
internal class Post: BaseDomain
{
    public string PostTitle { get; set; }
    public string Subject { get; set; }
    public string Summary { get; set; }
    public string PostBody { get; set; }

    #region Navigation
    public int PostWriterId { get; set; }
    public User PostWriter { get; set; }

    public int PostCategoryId { get; set; }
    public PostCategory PostCategory { get; set; }

    public ICollection<PostIssue> PostIssues { get; set; }
    public ICollection<PostComment> PostComments { get; set; }
    #endregion
}

internal class PostEntityConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);

        builder.Property(e => e.PostTitle).IsRequired()
            .HasMaxLength(Defaults.ShortLength4);

        builder.Property(e => e.Subject)
            .IsRequired().HasMaxLength(Defaults.ShortLength5);


        builder.Property(e => e.Summary)
            .IsRequired().HasMaxLength(Defaults.ShortLength8);


        builder.Property(e => e.PostBody)
            .IsRequired().HasMaxLength(Defaults.HugeLength);
        #endregion

        #region Navigations

        builder.HasOne(e => e.PostWriter).WithMany(e=>e.UserPosts).HasForeignKey(e=>e.PostWriterId);
        builder.HasOne(e => e.PostCategory).WithMany(e => e.CategoryPosts).HasForeignKey(e => e.PostCategoryId);

        #endregion
    }
}