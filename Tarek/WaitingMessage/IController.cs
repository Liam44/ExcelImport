using System;

namespace WaitingMessage
{
    public interface IController
    {
        bool Running { get; }
        bool Canceled { get; }
        void Display();
        void SetText(string text);
        void SetPercent(int percent, int progressBar = 0);
        void ReinitPercent(int progressBar = 0);
        void Failed(Exception e);
        void Completed(bool cancelled);
        void SetVisible(bool visible);
    }
}
