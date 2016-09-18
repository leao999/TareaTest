using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Model;
using WebDeveloper.Repository;
using Xunit;
using FluentAssertions;

namespace WebDeveloper.Tests.Repository
{
    public class BaseRepositoryTest
    {
        private IRepository<Person> repository;
        public BaseRepositoryTest()
        {
            repository = new BaseRepository<Person>();
        }

        [Fact(DisplayName = "AddTestWrongWithMissingData")]
        public void AddTestWrongWithMissingData()
        {
            var person = new Person();            
            person.PersonType = "SC";
            person.FirstName = "Test";
            person.LastName = "Test";
            person.rowguid = Guid.NewGuid();
            try
            {
                repository.Add(person);
            }
            catch (Exception exception)
            {
                exception.Source.Should().Be("EntityFramework");
            }
        }

        [Fact(DisplayName = "AddTestWrongWithNull")]
        public void AddTestWrongWithNull()
        {
            var person = new Person();
            try
            {
                repository.Add(person);
            }
            catch (Exception exception)
            {
                exception.Should().NotBeNull();
            }            
        }

        [Fact(DisplayName = "AddTestWithProperData")]
        public void AddTestWithProperData()
        {
            var person = new Person();
            person.PersonType = "SC";
            person.FirstName = "Test";
            person.LastName = "Test";
            person.rowguid = Guid.NewGuid();
            person.ModifiedDate = DateTime.Now;
            person.BusinessEntity = new BusinessEntity
            {
                ModifiedDate = person.ModifiedDate,
                rowguid = person.rowguid
            };
            var result = repository.Add(person);
            result.Should().BeGreaterThan(0);
        }
        

        [Fact(DisplayName = "UpdateTestWrongWithMissingData")]
        public void UpdateTestWrongWithMissingData()
        {
            var person = new Person();
            person.PersonType = "SC";
            person.FirstName = "Test";
            person.LastName = "Test";
            person.rowguid = Guid.NewGuid();
            try
            {
                repository.Update(person);
            }
            catch (Exception exception)
            {
                exception.Source.Should().Be("EntityFramework");
            }
        }
        [Fact(DisplayName = "UpdateTestWrongWithNull")]
        public void UpdateTestWrongWithNull()
        {
            var person = new Person();
            try
            {
                repository.Update(person);
            }
            catch (Exception exception)
            {
                exception.Should().NotBeNull();
            }
        }
        [Fact(DisplayName = "DeleteTestWrongWithMissingData")]
        public void DeleteTestWrongWithMissingData()
        {
            var person = new Person();
            person.PersonType = "SC";
            person.FirstName = "Test";
            person.LastName = "Test";
            person.rowguid = Guid.NewGuid();
            try
            {
                repository.Delete(person);
            }
            catch (Exception exception)
            {
                exception.Source.Should().Be("EntityFramework");
            }
        }
        [Fact(DisplayName = "DeleteTestWrongWithNull")]
        public void DeleteTestWrongWithNull()
        {
            var person = new Person();
            try
            {
                repository.Delete(person);
            }
            catch (Exception exception)
            {
                exception.Should().NotBeNull();
            }
        }
    }
}
