﻿using Microsoft.AspNetCore.Identity;

namespace Bookify.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
