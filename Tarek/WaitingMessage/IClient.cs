﻿using System;

namespace WaitingMessage
{
    interface IClient
    {
        void Start(IController controller);
        void Display();
        void SetText(string text);
        void Failed(Exception e);
        void Completed(bool cancelled);
        void SetVisible(bool visible);
    }
}
