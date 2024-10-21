namespace Memory2.Scripts.Core.ShowStates.Interfaces {
    public interface IVisibilityService {
        void SubscribeToShow(IShow show);
        void SubscribeToHide(IHide hide);
    }
}