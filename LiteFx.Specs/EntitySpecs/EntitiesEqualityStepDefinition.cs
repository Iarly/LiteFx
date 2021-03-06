﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LiteFx.Specs.EntitySpecs
{
    [Binding]
    class EntitiesEqualityStepDefinition
    {
        EntityBase<int> entity;
        EntityBase<int> anotherEntity;
        object ordinaryObject;

        bool equality;
        bool diference;

        HashSet<EntityBase<int>> hashSet;

        [Given(@"I have a product instance with the id (.*)")]
        public void GivenIHaveAProductInstanceWithTheId(int id)
        {
            entity = new Product() { Id = id };
        }

        [Given(@"I have another product instance with the id (.*)")]
        public void GivenIHaveAnotherProductInstanceWithTheId(int id)
        {
            anotherEntity = new Product() { Id = id };
        }

        [Given(@"I have a boxed product instance with the id (.*) in ordinary object")]
        public void GivenIHaveAnotherProductInstanceWithTheIdBoxedInOrdinaryObject(int id)
        {
            ordinaryObject = new Product() { Id = id };
        }

        [Given(@"I have the same product instance")]
        public void GivenIHaveTheSameProductInstance()
        {
            anotherEntity = entity;
        }

        [Given(@"I have a category instance with the id (.*)")]
        public void GivenIHaveACategoryInstanceWithTheId(int id)
        {
            anotherEntity = new Category() { Id = id };
        }

        [Given(@"I have a null product")]
        public void GivenIHaveANullProduct()
        {
            entity = null;
        }

        [Given(@"I have another null product")]
        public void GivenIHaveAnotherNullProduct()
        {
            anotherEntity = null;
        }

        [Given(@"I have an ordinary object")]
        public void GivenIHaveAnOrdinaryObject()
        {
            ordinaryObject = new object();
        }

        [Given(@"I have a null ordinary object")]
        public void GivenIHaveANullOrdinaryObject()
        {
            ordinaryObject = null;
        }

        [Given(@"a HashSet instance")]
        public void GivenAHashSetInstance()
        {
            hashSet = new HashSet<EntityBase<int>>();
        }

        [When(@"I compare the two instances")]
        public void WhenICompareTheTwoInstances()
        {
            equality = entity == anotherEntity;
        }

        [When(@"I check the diference of the two instances")]
        public void WhenICheckTheDiferenceOfTheTwoInstances()
        {
            diference = entity != anotherEntity;
        }

        [When(@"I compare the entity with the ordinary object")]
        public void WhenICompareTheEntityWithTheOrdinaryObject()
        {
            equality = entity.Equals(ordinaryObject);
        }

        [When(@"I compare the Hash Code of this two instances")]
        public void WhenICompareTheHashCodeOfThisTwoInstances()
        {
            equality = entity.GetHashCode() == anotherEntity.GetHashCode();
        }

        [When(@"I add the two instances to a HashSet")]
        public void WhenIAddTheTwoInstancesToAHashSet()
        {
            hashSet.Add(entity);
            hashSet.Add(anotherEntity);
        }

        [Then(@"the equality should be (.*)")]
        public void ThenTheEqualityShouldBe(bool result)
        {
            Assert.AreEqual(result, this.equality);
        }

        [Then(@"the diference should be (.*)")]
        public void ThenTheDiferenceShouldBeFalse(bool result)
        {
            Assert.AreEqual(result, this.diference);
        }
        
        [Then(@"the HashSet count should be (.*)")]
        public void ThenTheHashSetCountShouldBe(int count)
        {
            Assert.AreEqual(count, hashSet.Count);
        }
    }
}
