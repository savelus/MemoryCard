namespace Memory2.Scripts.Game.Global.MVP.ShowStates.Interfaces {
    public interface IVisibilityService {
        void SubscribeToShow(IShow show);

        void SubscribeToHide(IHide hide);
    }
}