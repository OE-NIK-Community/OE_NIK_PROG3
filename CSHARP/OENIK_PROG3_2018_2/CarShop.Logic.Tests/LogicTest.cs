﻿// <copyright file="LogicTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CarShop.Data;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// LogicTest is the main class which handles Tests for the Logic class.
    /// It uses MOQ, and NUNIT3 Adapters to test method calls with injection, and
    /// such.
    /// </summary>
    [TestFixture]
    public class LogicTest
    {
        /// <summary>
        /// A simple insert check.
        /// </summary>
        [Test]
        public void SimpleInsertCheck()
        {
            Logic m = Mock.Of<Logic>();
            Mock<Logic> m2 = Mock.Get(m);
            List<automarkak> lista = new List<automarkak>() { new automarkak() { Id = 666666, alapitaseve = 1997, evesforgalom = 50, nev = "xdd", orszagnev = "xddddddd", url = "xdddurl" } };

            m2.Setup(x => x.Helper.BrandRepository.GetAll()).Returns(lista.AsQueryable());
            m2.Object.InsertBrandData("ciabébi", "xd", "xd", 2000, 200000);
            m2.Verify(mock => mock.InsertBrandData("ciabébi", "xd", "xd", 2000, 200000), Times.Once());
        }

        /// <summary>
        /// A simple update check.
        /// </summary>
        /// <param name="value">Id of car.</param>
        [Test]
        [Sequential]
        public void UpdateCarCheck([Values(100)] int value)
        {
            Logic m = Mock.Of<Logic>();
            Mock<Logic> m2 = Mock.Get(m);
            List<modellek> lista = new List<modellek>();
            lista.Add(new modellek() { Id = 100, alapar = 500, loero = 500, marka_id = 1, megjelenesnapja = new DateTime(2000, 01, 01), motorterfogat = 300, nev = "tütü" });

            m2.Setup(x => x.Helper.CarRespository.GetAll()).Returns(lista.AsQueryable());

            Assert.That(m2.Object.UpdateCarData(value, 1, "teszt update", new DateTime(2000, 01, 01), 500, 500, 5000), Is.True);
            Assert.That(lista[0].nev, Is.EqualTo("teszt update"));

            // If I were to verify the Delete function, then Delete needs to be virtual.
            m2.Verify(mock => mock.Helper.CarRespository.GetAll(), Times.AtLeastOnce);
        }

        /// <summary>
        /// A simple car deletion check.
        /// </summary>
        /// <param name="value">int.</param>
        [Test]
        [Sequential]
        public void CarDeletionCheck([Values(100)] int value)
        {
            Logic m = Mock.Of<Logic>();
            Mock<Logic> m2 = Mock.Get(m);
            List<modellek> lista = new List<modellek>();
            for (int i = 1; i < 251; i++)
            {
                lista.Add(new modellek() { Id = i, alapar = 500, loero = 500, marka_id = 1, megjelenesnapja = new DateTime(2000, 01, 01), motorterfogat = 300, nev = "tütü" });
            }

            m2.Setup(x => x.Helper.CarRespository.GetAll()).Returns(lista.AsQueryable());

            Assert.That(m2.Object.DeleteCarData(value), Is.True);

            // If I were to verify the Delete function, then Delete needs to be virtual.
            m2.Verify(mock => mock.Helper.CarRespository.GetAll(), Times.AtLeastOnce);
        }

        /// <summary>
        /// This method checks if the given values from 1-250 are inside our fake list.
        /// </summary>
        /// <param name="value">The ID of the car.</param>
        [Test]
        [Sequential]
        public void CarExistenceCheck([Values(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222)] int value)
        {
            Logic m = Mock.Of<Logic>();
            Mock<Logic> m2 = Mock.Get(m);
            List<modellek> lista = new List<modellek>();
            for (int i = 1; i < 223; i++)
            {
                lista.Add(new modellek() { Id = i, alapar = 500, loero = 500, marka_id = 1, megjelenesnapja = new DateTime(2000, 01, 01), motorterfogat = 300, nev = "tütü" });
            }

            m2.Setup(x => x.Helper.CarRespository.GetAll()).Returns(lista.AsQueryable());

            Assert.That(m2.Object.CheckIfCarIDExists(value), Is.True);
            m2.Verify(mock => mock.Helper.CarRespository.GetAll(), Times.AtLeastOnce);
        }

        /// <summary>
        /// This method checks if the given values from 1-250 are inside our fake list.
        /// </summary>
        /// <param name="value">The ID of the brand.</param>
        [Test]
        [Sequential]
        public void BrandsExistenceTest([Values(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221)] int value)
        {
            Logic m = Mock.Of<Logic>();
            Mock<Logic> m2 = Mock.Get(m);
            List<automarkak> lista = new List<automarkak>();
            for (int i = 1; i < 222; i++)
            {
                lista.Add(new automarkak() { Id = i, alapitaseve = 1997, evesforgalom = 50, nev = "xdd", orszagnev = "xddddddd", url = "xdddurl" });
            }

            m2.Setup(x => x.Helper.BrandRepository.GetAll()).Returns(lista.AsQueryable());

            Assert.That(m2.Object.CheckIfBrandExists(value), Is.True);
            m2.Verify(mock => mock.Helper.BrandRepository.GetAll(), Times.AtLeastOnce);
        }

        /// <summary>
        /// This method checks if the given values from 1-250 are inside our fake list.
        /// </summary>
        /// <param name="value">The ID of the extra.</param>
        [Test]
        [Sequential]
        public void ExtraExistenceTest([Values(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220)] int value)
        {
            Logic m = Mock.Of<Logic>();
            Mock<Logic> m2 = Mock.Get(m);
            List<extrak> lista = new List<extrak>();
            for (int i = 1; i < 221; i++)
            {
                lista.Add(new extrak() { Id = i, ar = 50, kategorianev = "valami", nev = "xd", szin = "piros", tobbszor_hasznalhato = 1 });
            }

            m2.Setup(x => x.Helper.ExtraRepository.GetAll()).Returns(lista.AsQueryable());

            Assert.That(m2.Object.CheckIfExtraIDExists(value), Is.True);
            m2.Verify(mock => mock.Helper.ExtraRepository.GetAll(), Times.AtLeastOnce);
        }
    }
}