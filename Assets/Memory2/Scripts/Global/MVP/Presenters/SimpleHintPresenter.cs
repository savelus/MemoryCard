using System;
using Cysharp.Threading.Tasks;
using Memory2.Scripts.Core.MVP.Base;
using Memory2.Scripts.Core.MVP.Context;
using Memory2.Scripts.Global.MVP.Data;
using Memory2.Scripts.Global.MVP.Enums;
using Memory2.Scripts.Global.MVP.Interfaces;
using UnityEngine;
using Zenject.Internal;

namespace Memory2.Scripts.Global.MVP.Presenters {
    [Preserve]
    public class SimpleHintPresenter : BaseWindowPresenter<ISimpleHintView, HintData> {
        protected override async UniTask LoadContent() {
            var position = new Vector2();
            var hintSize = View.GetSize();
            switch (WindowData.PositionType) {
                case HintPosition.UpPosition:
                    position.x = WindowData.Position.x + hintSize.x / 2f;
                    position.y = WindowData.Position.y;
                    break;
                case HintPosition.CenterPosition:
                    position = WindowData.Position;
                    break;
                case HintPosition.DownPosition:
                    position.x = WindowData.Position.x - hintSize.x / 2f;
                    position.y = WindowData.Position.y;
                    break;
                case HintPosition.ScreenCenter:
                default:
                    position.x = 0;
                    position.y = 0;
                    break;
            }

            View.Init(WindowData.HintText, position);
        }

        public SimpleHintPresenter(IContextService service) : base(service) { }
    }
}