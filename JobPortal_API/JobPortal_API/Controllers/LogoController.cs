using AutoMapper;
using AutoMapper.QueryableExtensions;
using JobPortal_API.Data;
using JobPortal_API.DTOs;
using JobPortal_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobPortal_API.Controllers
{
    [ApiController]
    [Route("api/logo")]
    public class LogoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public LogoController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //todos os registros
        [HttpGet]
        public async Task<IEnumerable<LogoEmpresaDTO>> GetLogo()
        {
            return await _context.LogoEmpresa.ProjectTo<LogoEmpresaDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }
        //busca por ID da Empresa
        [HttpGet("{id}")]
        public async Task<ActionResult<LogoEmpresaDTO>> GetLogo(int idEmpresa)
        {
            if (_context.LogoEmpresa == null)
            {
                return NotFound();
            }
            var logo = _context.LogoEmpresa.ProjectTo<LogoEmpresaDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(m => m.IdEmpresaFoto == idEmpresa);
            if (logo == null)
            {
                return NotFound();
            }

            return await logo;
        }

        
        //Criar logo
        [HttpPost]
        public async Task<ActionResult> PostLogo(LogoEmpresaDTO logoDTO)
        {
            var logo = _mapper.Map<LogoEmpresa>(logoDTO);
            _context.Add(logo);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //Edit/Update pelo id da empresa
        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutLogo(LogoEmpresaDTO logoDTO, int id)
        {
            var logo = await _context.LogoEmpresa.FirstOrDefaultAsync(c => c.IdEmpresaFoto == id);
            if (logo == null)
            {
                return NotFound();
            }
            logo = _mapper.Map(logoDTO, logo);

            await _context.SaveChangesAsync();
            return Ok();
        }
        //delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteLogo(int id)
        {
            var logo = await _context.LogoEmpresa.FirstOrDefaultAsync(c => c.IdEmpresaFoto == id);
            if (logo == null)
            {
                return NotFound();
            }
            _context.LogoEmpresa.Remove(logo);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}