using QuestionAndChalleger.Domain.Entities;
using QuestionAndChalleger.Manager.Interfaces.Repository;
using QuestionAndChalleger.FakeData.QuestionData;
using Microsoft.EntityFrameworkCore;
using Xunit;
using QuestionAndChalleger.Data.Repository;
using FluentAssertions;

namespace QuestionAndChalleger.Data.Tests.Repository
{
    public class QuestionRepositoryTest : IDisposable
    {
        private readonly IQuestionRepository _repository;
        private readonly QuestionAndChallegerContext _context;
        private readonly Question _question;
        private readonly QuestionFaker _questionFaker;

        public QuestionRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<QuestionAndChallegerContext>();
            optionsBuilder.UseInMemoryDatabase("Db_Tests");
            optionsBuilder.EnableSensitiveDataLogging();

            _context = new QuestionAndChallegerContext(optionsBuilder.Options);
            _repository = new QuestionRepository(_context);

            _questionFaker = new QuestionFaker();
            _question = _questionFaker.Generate();
        }

        private async Task<List<Question>> InsertQuestions()
        {
            var questions = _questionFaker.Generate(100);
            foreach (var question in questions)
            {
                question.Id = 0;
                await _context.Questions.AddAsync(question);
            }
            await _context.SaveChangesAsync();
            return questions;
        }

        [Fact]
        public async Task GetAllAsync_WithReturn()
        {
            var inserts = await InsertQuestions();
            var result = await _repository.GetAllAsync();

            result.Should().HaveCount(inserts.Count);
            result.First().Description.Should().NotBeNullOrEmpty();
            result.First().Category.Should().NotBe(null);
            result.First().Id.Should().NotBe(null);
        }

        [Fact]
        public async Task GetAllAsync_Empty()
        {
            var result = await _repository.GetAllAsync();
            result.Should().HaveCount(0);
        }

        [Fact]
        public async Task GetById_Found()
        {
            var inserts = await InsertQuestions();
            var result = await _repository.GetByIdAsync(inserts.First().Id);

            result.Should().BeEquivalentTo(inserts.First());
        }

        [Fact]
        public async Task GetById_NotFound()
        {
            var result = await _repository.GetByIdAsync(1);
            result.Should().BeNull();
        }

        [Fact]
        public async Task InsertAsync_Sucess()
        {
            var result = await _repository.InsertAsync(_question);
            result.Should().BeEquivalentTo(_question);
        }

        [Fact]
        public async Task UpdateAsync_Sucess()
        {
            var inserts = await InsertQuestions();
            var questionFind = inserts.First();
            questionFind.Description += "update";
            var result = await _repository.UpdateAsync(questionFind);
            result.Should().BeEquivalentTo(questionFind);
        }

        [Fact]
        public async Task UpdateAsync_NotFound()
        {
            var result = await _repository.UpdateAsync(_question);
            result.Should().BeNull();
        }

        [Fact]
        public async Task DeleteAsync_Sucess()
        {
            var inserts = await InsertQuestions();
            var questionForRemove = inserts.First();
            var result = await _repository.DeleteAsync(questionForRemove.Id);
            result.Should().BeEquivalentTo(questionForRemove);
        }

        [Fact]
        public async Task DeleteAsync_NotFound()
        {
            var result = await _repository.DeleteAsync(1);
            result.Should().BeNull();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
