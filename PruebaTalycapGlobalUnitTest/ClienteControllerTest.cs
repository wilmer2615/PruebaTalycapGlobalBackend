using DataTransferObjects;
using Logic.ClienteLogic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PruebaTalycapGlobal.Controllers;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PruebaTalycapGlobalUnitTest
{
    public class ClienteControllerTest
    {

        private ClienteController CreateController(IClienteLogic clienteLogic)
        {
            return new ClienteController(clienteLogic);
        }

        [Fact]
        public async Task Agregar_ClienteValido_RetornaOkResultadoclienteDto()
        {
            // Arrange
            var clienteDto = new ClienteDto
            {
                Id = 1,
                Direccion = "Calle 45 # 17-50",
                Nombre = "John Doe",
                Email = "JhonDoe@gmail.com",
                NumeroIdentificacion = "1452369874"
            };

            var mockService = new Mock<IClienteLogic>();
            mockService.Setup(logic => logic.AddAsync(It.IsAny<ClienteDto>()))
                .ReturnsAsync(clienteDto);

            var controller = CreateController(mockService.Object);

            // Act
            var result = await controller.Add(clienteDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var resultModel = Assert.IsAssignableFrom<ClienteDto>(okResult.Value);
            Assert.Equal(clienteDto, resultModel);
        }

        [Fact]
        public async Task Agregar_ClienteInvalido_RetornaBadRequestResultadoError()
        {
            // Arrange
            var clienteDto = new ClienteDto
            {
                Id = 1,
                Direccion = "Calle 45 # 17-50",
                Nombre = "John Doe",
                Email = "JhonDoe@gmail.com",
                NumeroIdentificacion = "1452369874"
            };

            var mockService = new Mock<IClienteLogic>();
            mockService.Setup(logic => logic.AddAsync(It.IsAny<ClienteDto>()))
                .ReturnsAsync(clienteDto);

            var controller = CreateController(mockService.Object);
            controller.ModelState.AddModelError("Identificacion", "La longitud maxima para el campo NumeroIdentificacion es de 10 caracteres.");

            // Act
            var result = await controller.Add(clienteDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var errors = Assert.IsType<SerializableError>(badRequestResult.Value);
            Assert.True(errors.ContainsKey("Identificacion"));
        }

        [Fact]
        public async Task ObtenerTodos_RetornaOkResultadoUnaListaClientes()
        {
            // Arrange
            var clientes = new List<ClienteDto>
            {
                new ClienteDto {
                    Id = 1,
                    Direccion = "Calle 65 # 23-50",
                    Nombre = "Diana lopez",
                    Email = "dianalopez@gmail.com",
                    NumeroIdentificacion = "526398741"
                },
                new ClienteDto {
                    Id = 2,
                    Direccion = "Calle 45 # 17-50",
                    Nombre = "John Doe",
                    Email = "JhonDoe@gmail.com",
                    NumeroIdentificacion = "1452369874"
                },
                new ClienteDto {
                    Id = 3,
                    Direccion = "Calle 11 # 37-62",
                    Nombre = "Luis peña",
                    Email = "luispeña@gmail.com",
                    NumeroIdentificacion = "1032654953"
                },
            };

            var mockService = new Mock<IClienteLogic>();
            mockService.Setup(logic => logic.GetAllAsync()).ReturnsAsync(clientes);

            var controller = CreateController(mockService.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var resultList = Assert.IsAssignableFrom<List<ClienteDto>>(okResult.Value);
            Assert.Equal(clientes, resultList);
        }

        [Fact]
        public async Task ObtenerTodos_RetornaNotFoundResultadoUnObjetoNull()
        {
            // Arrange
            var mockService = new Mock<IClienteLogic>();
            mockService.Setup(logic => logic.GetAllAsync()).ReturnsAsync(() => null);

            var controller = CreateController(mockService.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task ActualizarCliente_RetornaOkResultado()
        {
            // Arrange
            var clienteDto = new ClienteDto
            {
                Id = 1,
                Direccion = "Calle 45 # 17-50",
                Nombre = "John Doe",
                Email = "JhonDoe@gmail.com",
                NumeroIdentificacion = "1452369874"
            };

            var mockService = new Mock<IClienteLogic>();
            mockService.Setup(logic => logic.UpdateAsync(It.IsAny<int>(), It.IsAny<ClienteDto>()))
                .ReturnsAsync(clienteDto);

            var controller = CreateController(mockService.Object);

            // Act
            var result = await controller.Update(clienteDto.Id, clienteDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var updatedCliente = Assert.IsType<ClienteDto>(okResult.Value);
            Assert.Equal(clienteDto, updatedCliente);
        }

        [Fact]
        public async Task EliminarCliente_RetornaNoContentResultado()
        {
            // Arrange
            var clienteId = 1;

            var mockService = new Mock<IClienteLogic>();
            mockService.Setup(logic => logic.RemoveAsync(It.IsAny<int>()))
                .ReturnsAsync(new ClienteDto());

            var controller = CreateController(mockService.Object);

            // Act
            var result = await controller.Remove(clienteId);

            // Assert
            var noContentResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, noContentResult.StatusCode);
        }


    }
}
