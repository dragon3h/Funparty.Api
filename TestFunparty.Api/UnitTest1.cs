using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Funparty.Api.Application.Dtos;
using Funparty.Api.Application.Interfaces;
using Funparty.Api.Controllers;
using Funparty.Api.Domain.Entities;
using Funparty.Api.Helpers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace TestFunparty.Api
{
    public class UnitTest1
    {
        [Fact]
        public async Task GetMascots_ReturnAllMascots()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfiles()));
            var mockRepo = new Mock<IMascotRepository>();
            mockRepo.Setup(repo => repo.GetAllMascots()).ReturnsAsync(GetMascots());
            var controller = new MascotController(mockRepo.Object, config.CreateMapper());
            
            // Act
            var result = await controller.GetMascots();
            
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnMascot = Assert.IsType<List<MascotDto>>(okResult.Value);
            var mascot = returnMascot.FirstOrDefault();
            Assert.Equal("Micky", mascot.Name);
        }

        #region snipet_GetMascots

        private List<Mascot> GetMascots()
        {
            var mascots = new List<Mascot>();
            mascots.Add(new Mascot()
            {
                Id = 1,
                Category = "Regular",
                CreatedDate = new DateTime(2018, 11, 22),
                Name = "Micky",
                RentPrice = 50.0M,
                SalePrice = 150M,
                UpdatedDate = new DateTime(2019, 1, 2)
            });
            
            mascots.Add(new Mascot()
            {
                Id = 2,
                Category = "Regular",
                CreatedDate = new DateTime(2018, 12, 2),
                Name = "Minny",
                RentPrice = 50.0M,
                SalePrice = 150M,
                UpdatedDate = new DateTime(2019, 1, 2)
            });

            return mascots;
        }

        #endregion
    }
}