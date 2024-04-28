﻿namespace SoftwareCrafters.SF_Module_6.CodeSmells.MessageChains;

public class Address
{
    public Address(Country country)
    {
        this.Country = country;
    }

    public Country Country { get; private set; }
}