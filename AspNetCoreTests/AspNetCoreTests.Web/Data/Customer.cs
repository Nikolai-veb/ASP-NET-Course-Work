﻿using System;

namespace AspNetCoreTests.Web.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}