using System;
using TASKMANAGER.DB.Entities.Abstract;
using TASKMANAGER.DB.Enums;

namespace TASKMANAGER.DB.Entities.Concrete
{
    public class Project : Entity
    {
        public Guid PublicId { get; protected set; }
        public string Name { get; protected set; }
        public int Status { get; protected set; }
        public long TeamId { get; protected set; }
        public virtual Team Team { get; protected set; }
        public Project() {}

        public Project(string name, ProjectStatusEnum status, long teamId)
        {
            SetPublicId();
            ChangeName(name);
            ChangeStatus(status);
            ChangeTeam(teamId);
        }

        public void Update(string name, ProjectStatusEnum status, long teamId)
        {
            ChangeName(name);
            ChangeStatus(status);
            ChangeTeam(teamId);
        }

        private void SetPublicId()
        {
            PublicId = Guid.NewGuid();
        }

        private void ChangeName(string name)
        {
            Name = name;
        }

        private void ChangeTeam(long id)
        {
            TeamId = id;
        }

        private void ChangeStatus(ProjectStatusEnum status)
        {
            Status = (int) status;
        }

    }
}
