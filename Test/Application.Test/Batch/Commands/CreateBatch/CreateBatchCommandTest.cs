using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Batch.Commands.CreateBatch;
using Application.Batch.Queries.GetBatchDetail;
using Application.Test.Common;
using MediatR;
using Moq;
using NUnit.Framework;

namespace Application.Test.Batch.Commands.CreateBatch
{
    public class CreateBatchCommandTest : CommandTestBase
    {
        [Test]
        public async Task Handler()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var sut = new CreateBatchCommandHandler(_context);
            var command = new CreateBatchCommand
            {
                BusinessUnit = "Demo0 BU",
                ExpiryDate = DateTime.Now.AddMonths(5),
                Acl = new BatchAclModel(){
                    ReadGroups = new List<string>{
                        "TestReadGroup"
                    },
                    ReadUsers = new List<string>{
                        "TestReadUser"
                    },
                }
            };

            // Act
            var result = await sut.Handle(command, CancellationToken.None);


            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Guid>(result);
            //mediatorMock.Verify(m => m.Publish(It.Is<CreateBatchCommand>(cc => cc.id == newCustomerId), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}