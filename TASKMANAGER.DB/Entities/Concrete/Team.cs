using System;
using System.Collections.Generic;
using TASKMANAGER.DB.Entities.Abstract;

namespace TASKMANAGER.DB.Entities.Concrete
{
    public class Team : Entity
    {
        public Guid PublicId { get; protected set; }
        public string Name { get; protected set; }
        public long CreatedById { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public virtual User CreatedBy { get; protected set; }
        public virtual List<UserTeam> TeamUsers { get; protected set; }
        public virtual List<Project> Projects { get; protected set; }
        public Team() { }

        public Team(string name, long userId)
        {
            SetPublicId();
            ChangeName(name);
            SetCreatedBy(userId);
            SetCreatedDate();
        }

        private void SetPublicId()
        {
            PublicId = Guid.NewGuid();
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        private void SetCreatedBy(long userId)
        {
            CreatedById = userId;
        }

        private void SetCreatedDate()
        {
            CreatedAt = DateTime.Now;
        }

    }
}
