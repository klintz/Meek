﻿namespace Meek.Web.Mvc
{
    public interface IViewConfig
    {
        string Name { get; }
        
        string File { get; }

        string Master { get; }
        
        bool Themed { get; }

        bool Active { get; }
    }
}