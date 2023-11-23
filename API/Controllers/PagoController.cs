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
    public class PagoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public PagoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PagoDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Pagos.GetAllAsync();
            var PagoListDto = _mapper.Map<List<PagoDto>>(registers);
            return PagoListDto;
        }
        
        [HttpPost]
        public async Task<ActionResult<Pago>> Post(PagoDto PagoDto)
        {
            var Pago = _mapper.Map<Pago>(PagoDto);
            _unitOfWork.Pagos.Add(Pago);
            await _unitOfWork.SaveAsync();
            PagoDto.Id = Pago.Id;
            return CreatedAtAction(nameof(Post), new { id = PagoDto.Id }, PagoDto);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<PagoDto>> Put(
            int id,
            [FromBody] PagoDto PagoDto
        )
        {
            if (PagoDto == null)
            {
                return NotFound(404);
            }
            var Pago = _mapper.Map<Pago>(PagoDto);
            _unitOfWork.Pagos.Update(Pago);
            await _unitOfWork.SaveAsync();
            return PagoDto;
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var Pago = await _unitOfWork.Pagos.GetByIdAsync(id);
            _unitOfWork.Pagos.Remove(Pago);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
        [HttpGet("PagosEn2008Paypal")]
        public async Task<IEnumerable<PagoDto>> PagosEn2008Paypal ()
        {
            var r = await _unitOfWork.Pagos.PagosEn2008Paypal();
            return _mapper.Map<List<PagoDto>>(r);
        }
        [HttpGet("PosiblesEstadosDePago")]
        public async Task<IEnumerable<Formas_Pago>> PosiblesEstadosDePago ()
        {
            var r = await _unitOfWork.Pagos.PosiblesEstadosDePago();
            return _mapper.Map<List<Formas_Pago>>(r);
        }
    }
}