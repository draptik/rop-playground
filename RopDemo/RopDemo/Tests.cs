﻿using FluentAssertions;
using Xunit;

namespace RopDemo
{
    public class Tests
    {
        [Fact]
        public void SmokeTest()
        {
            1.ToString().Should().Be("1");
        }
    }
}