﻿namespace SoftwareCrafters.SF_Module_6.CodeSmells.MessageChains;

public class Country
{
    public Country(bool inEurope)
    {
        this.IsInEurope = inEurope;
    }

    public bool IsInEurope { get; private set; }
}