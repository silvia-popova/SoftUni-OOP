﻿namespace InfernoInfinity.Contracts
{
    public interface IGemFactory
    {
        IGem CreateGem(string gemType, string gemClarity);
    }
}
