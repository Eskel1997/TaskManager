using TASKMANAGER.DB.Entities.Abstract;

namespace TASKMANAGER.DB.Entities.Concrete
{
    public class UserTeam : Entity
    {
        public long AddedById { get; protected set; }
        public long UserId { get; protected set; }
        public long TeamId { get; protected set; }
        public virtual User AddedBy { get; protected set; }
        public virtual User User { get; protected set; }
        public virtual Team Team { get; protected set; }

        public UserTeam() {}

        public UserTeam(long userId, long teamId, long addedById)
        {
            SetAddedBy(addedById);
            SetUser(userId);
            SetTeam(teamId);
        }

        private void SetAddedBy(long addedById)
        {
            AddedById = addedById;
        }

        private void SetUser(long userId)
        {
            UserId = userId;
        }

        private void SetTeam(long teamId)
        {
            TeamId = teamId;
        }
    }
}
