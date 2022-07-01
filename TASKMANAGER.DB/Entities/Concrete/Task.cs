using System;
using System.Collections.Generic;
using TASKMANAGER.DB.Entities.Abstract;

namespace TASKMANAGER.DB.Entities.Concrete
{
    public class Task : Entity
    {
        public Guid PublicId { get; protected set; }
        public string Name { get; protected set; }
        public int Priority { get; protected set; }
        public string Description { get; protected set; }
        public long ProjectId { get; protected set; }
        public long CreatedById { get; protected set; }
        public long OwnerId { get; protected set; }
        public int Status { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public virtual List<Comment> Comments { get; protected set; }
        public virtual Project Project { get; protected set; }
        public virtual User CreatedBy { get; protected set; }
        public virtual User Owner { get; protected set; }
        public Task() {}

        public Task(string name, int priority, string description, long projectId,
            long createdById, long ownerId, int status)
        {
            SetPublicId();
            SetCreatedBy(createdById);
            SetCreatedAt();
            ChangeName(name);
            ChangePriority(priority);
            ChangeDescription(description);
            ChangeProject(projectId);
            ChangeStatus(status);
            ChangeOwner(ownerId);
        }

        public void Update(string name, int priority, string description,
            long projectId, long ownerId, int status)
        {
            ChangeName(name);
            ChangePriority(priority);
            ChangeDescription(description);
            ChangeProject(projectId);
            ChangeStatus(status);
            ChangeOwner(ownerId);
        }
        private void SetPublicId()
        {
            PublicId = Guid.NewGuid();
        }

        private void SetCreatedAt()
        {
            CreatedAt = DateTime.Now;
        }

        private void SetCreatedBy(long createdBy)
        {
            CreatedById = createdBy;
        }

        private void ChangeName(string name)
        {
            Name = name;
        }

        private void ChangePriority(int priority)
        {
            Priority = priority;
        }

        private void ChangeDescription(string description)
        {
            Description = description;
        }

        private void ChangeStatus(int status)
        {
            Status = status;
        }

        private void ChangeProject(long id)
        {
            ProjectId = id;
        }

        private void ChangeOwner(long id)
        {
            OwnerId = id;
        }
    }
}
