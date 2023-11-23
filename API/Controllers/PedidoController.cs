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
    public class PedidoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PedidoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Pedidos.GetAllAsync();
            var PedidoListDto = _mapper.Map<List<PedidoDto>>(registers);
            return PedidoListDto;
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> Post(PedidoDto PedidoDto)
        {
            var Pedido = _mapper.Map<Pedido>(PedidoDto);
            _unitOfWork.Pedidos.Add(Pedido);
            await _unitOfWork.SaveAsync();
            PedidoDto.Id = Pedido.Id;
            return CreatedAtAction(nameof(Post), new { id = PedidoDto.Id }, PedidoDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PedidoDto>> Put(int id, [FromBody] PedidoDto PedidoDto)
        {
            if (PedidoDto == null)
            {
                return NotFound(404);
            }
            var Pedido = _mapper.Map<Pedido>(PedidoDto);
            _unitOfWork.Pedidos.Update(Pedido);
            await _unitOfWork.SaveAsync();
            return PedidoDto;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Pedido = await _unitOfWork.Pedidos.GetByIdAsync(id);
            _unitOfWork.Pedidos.Remove(Pedido);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
        [HttpGet("PedidosPorEstado")]
        public async Task<ActionResult<IEnumerable<object>>> PedidosPorEstado()
        {
            
            var Pedidos = await _unitOfWork.Pedidos.GetAllAsync();
            var r = Pedidos.GroupBy(x=>x.Estado).Select(x => new {Estado = x.Key,Total = x.Count()}).OrderByDescending(x=>x.Total).ToList();
            return r;
        }
    }
}
