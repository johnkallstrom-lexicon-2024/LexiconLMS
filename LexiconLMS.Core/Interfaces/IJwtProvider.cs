﻿namespace LexiconLMS.Core.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
