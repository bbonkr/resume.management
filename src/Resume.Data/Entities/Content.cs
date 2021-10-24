using kr.bbon.Data;
using System.Collections.Generic;

namespace Resume.Data.Entities
{
    public class Content : Entity<long>
    {
        public string Title { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }
    }

    public class ContentItem : Entity<long>
    {
        public string Title {  get; set; }

        public string Subtitle { get; set; }

        public string Period { get; set; }

        public ContentItemState State { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ContentItemImage> ContentItemImages { get; set; }

        public virtual ICollection<ContentItemFeature> ContentItemFeatures {  get; set; }

        public virtual ICollection<ContentItemTag> ContentItemTags { get; set; }

        public virtual ICollection<ContentItemLink> ContentItemLinks { get; set; }        
    }

    public enum ContentItemState
    {
        [StringValue("입학")]
        Admissions,
        [StringValue("졸업")]
        Graduate,
        [StringValue("입사")]
        Join,
        [StringValue("퇴사")]
        Leave,
        [StringValue("완료")]
        Completed,
        [StringValue("진행중")]
        InProgress,
    }

    public class ContentItemImage : Entity
    {
        public long ContentItemId { get; set; }

        public long AttachmentId { get; set; }

        public virtual ContentItem ContentItem { get; set; }

        public virtual Attachment Image { get; set; }
    }

    public class ContentItemTag :Entity
    {
        public long ContentId { get; set; }

        public long TagId { get; set; }

        public virtual ContentItem ContentItem { get; set; }

        public virtual Tag Tag { get; set; }
    }

    public class ContentItemFeature:Entity
    {
        public long ContentItemId {  get; set; }
        public long FeatureId {  get; set; }

        public virtual ContentItem ContentItem { get; set; }

        public virtual Feature Feature {  get; set; }
    }

    public class ContentItemLink : Entity
    {
        public long ContentItemId { get; set; }

        public long LinkId { get; set; }

        public virtual ContentItem ContentItem { get; set; }

        public virtual Link Link { get; set; }
    }
}
