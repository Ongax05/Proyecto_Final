using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ClienteController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public ClienteController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Clientes.GetAllAsync();
            var ClienteListDto = _mapper.Map<List<ClienteDto>>(registers);
            return ClienteListDto;
        }
        
        [HttpPost]
        public async Task<ActionResult<Cliente>> Post(ClienteDto ClienteDto)
        {
            var Cliente = _mapper.Map<Cliente>(ClienteDto);
            _unitOfWork.Clientes.Add(Cliente);
            await _unitOfWork.SaveAsync();
            ClienteDto.Id = Cliente.Id;
            return CreatedAtAction(nameof(Post), new { id = ClienteDto.Id }, ClienteDto);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteDto>> Put(
            int id,
            [FromBody] ClienteDto ClienteDto
        )
        {
            if (ClienteDto == null)
            {
                return NotFound(404);
            }
            var Cliente = _mapper.Map<Cliente>(ClienteDto);
            _unitOfWork.Clientes.Update(Cliente);
            await _unitOfWork.SaveAsync();
            return ClienteDto;
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
            _unitOfWork.Clientes.Remove(Cliente);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
        [HttpGet("ClienteConRepNameYCiudad")]
        public async Task<ActionResult<IEnumerable<ClienteConRepNameYCiudad>>> ClienteConRepNameYCiudad()
        {
            var r = await _unitOfWork.Clientes.ClientesQueHanHechoPagosJuntoConRepInfo();
            return _mapper.Map<List<ClienteConRepNameYCiudad>>(r);
        }
        [HttpGet("ClientesQueNoHanRealizadoPagos")]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> ClientesQueNoHanRealizadoPagos()
        {
            var r = await _unitOfWork.Clientes.ClientesQueNoHanRealizadoPagos();
            return _mapper.Map<List<ClienteDto>>(r);
        }
        [HttpGet("ClientesJuntoConRepInfo")]
        public async Task<ActionResult<IEnumerable<ClienteConRepNameApellidoYCiudad>>> ClientesJuntoConRepInfo()
        {
            var r = await _unitOfWork.Clientes.ClientesJuntoConRepInfo();
            return _mapper.Map<List<ClienteConRepNameApellidoYCiudad>>(r);
        }
        [HttpGet("ClientesQueNoHanHechoPagosJuntoConRepInfo")]
        public async Task<ActionResult<IEnumerable<ClienteConRepNomApdOficinaTel>>> ClientesQueNoHanHechoPagosJuntoConRepInfo()
        {
            var r = await _unitOfWork.Clientes.ClientesQueNoHanHechoPagosJuntoConRepInfo();
            return _mapper.Map<List<ClienteConRepNomApdOficinaTel>>(r);
        }
    }
}