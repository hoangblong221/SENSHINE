﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Models;
using API.Services;


namespace API.Controllers
    {
        [Route("api")]
        [ApiController]
        public class PromotionController : ControllerBase
        {
            private readonly IPromotionService _promotionService;

            public PromotionController(IPromotionService promotionService)
            {
                _promotionService = promotionService;
            }

        [HttpPost("AddPromotion")]
      
            public async Task<ActionResult<Promotion>> AddPromotion([FromBody] PromotionDTO promotionDto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var promotion = await _promotionService.AddPromotion(promotionDto);
                return Ok(promotion);
        }

            
            [HttpPut("EditPromotion/{id}")]
            public async Task<IActionResult> EditPromotion(int id, [FromBody] PromotionDTO promotionDto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var promotion = await _promotionService.EditPromotion(id, promotionDto);
                if (promotion == null)
                {
                    return NotFound();
                }

                return NoContent();
            }

            
            [HttpGet("ListAllPromotion")]
            public async Task<ActionResult<IEnumerable<PromotionDTORequest>>> ListPromotions()
            {
                var promotions = await _promotionService.ListPromotion();
                return Ok(promotions);
            }

            
            [HttpGet("GetPromotionDetail{id}")]
            public async Task<ActionResult<PromotionDTO>> GetPromotionDetail(int id)
            {
                var promotion = await _promotionService.GetPromotionDetail(id);
                if (promotion == null)
                {
                    return NotFound();
                }

                return Ok(promotion);
            }

            
            [HttpGet("GetPromotionbyCode")]
            public async Task<ActionResult<IEnumerable<PromotionDTORequest>>> GetPromotionsByCode([FromQuery] string code)
            {
                var promotions = await _promotionService.PromotionByCode(code);
                if (promotions == null)
                {
                    return NotFound();
                }

                return Ok(promotions);
            }

            
            [HttpDelete("DeletePromotion/{id}")]
            public async Task<IActionResult> DeletePromotion(int id)
            {
                var result = await _promotionService.DeletePromotion(id);
                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
        }
    }


