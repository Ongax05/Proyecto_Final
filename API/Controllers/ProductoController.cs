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
    public class ProductoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public ProductoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Productos.GetAllAsync();
            var ProductoListDto = _mapper.Map<List<ProductoDto>>(registers);
            return ProductoListDto;
        }
        
        [HttpPost]
        public async Task<ActionResult<Producto>> Post(ProductoDto ProductoDto)
        {
            var Producto = _mapper.Map<Producto>(ProductoDto);
            _unitOfWork.Productos.Add(Producto);
            await _unitOfWork.SaveAsync();
            ProductoDto.Id = Producto.Id;
            return CreatedAtAction(nameof(Post), new { id = ProductoDto.Id }, ProductoDto);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductoDto>> Put(
            int id,
            [FromBody] ProductoDto ProductoDto
        )
        {
            if (ProductoDto == null)
            {
                return NotFound(404);
            }
            var Producto = _mapper.Map<Producto>(ProductoDto);
            _unitOfWork.Productos.Update(Producto);
            await _unitOfWork.SaveAsync();
            return ProductoDto;
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var Producto = await _unitOfWork.Productos.GetByIdAsync(id);
            _unitOfWork.Productos.Remove(Producto);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
        [HttpGet("ProductosQueNoHanEstadoEnPedidos")]
        public async Task<ActionResult<IEnumerable<ProductoNomDescImg>>> ProductosQueNoHanEstadoEnPedidos ()
        {
            var r = await _unitOfWork.Productos.ProductosQueNoHanEstadoEnPedidos();
            return _mapper.Map<List<ProductoNomDescImg>>(r);
        }
    }
}