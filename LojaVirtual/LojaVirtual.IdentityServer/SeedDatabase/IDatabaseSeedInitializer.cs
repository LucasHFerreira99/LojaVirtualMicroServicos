﻿namespace LojaVirtual.IdentityServer.SeedDatabase;

public interface IDatabaseSeedInitializer
{
    void InitializeSeedRoles();
    void InitializeSeedUsers();
    void InitializeSeedDatabase();
}
