using System;
using TASKMANAGER.DB.Entities.Abstract;

namespace TASKMANAGER.DB.Entities.Concrete
{
    public class Comment : Entity
    {
        public Guid PublicId { get; protected set; }
        public string Text { get; protected set; }
        public long TaskId { get; protected set; }
        public long CreatedById { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public virtual Task Task { get; protected set; }
        public virtual User CreatedBy { get; protected set; }

        public Comment() {}

        public Comment(string text, long taskId, long userId)
        {
            SetPublicId();
            ChangeText(text);
            SetCreatedBy(userId);
            SetTask(taskId);
            CreatedAt = DateTime.UtcNow;
        }

        public void ChangeText(string text)
        {
            Text = text;
        }
        private void SetPublicId()
        {
            PublicId = Guid.NewGuid();
        }

        private void SetCreatedBy(long createdById)
        {
            CreatedById = createdById;
        }

        private void SetTask(long taskId)
        {
            TaskId = taskId;
        }
    }
}
