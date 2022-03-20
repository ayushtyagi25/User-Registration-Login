using LLM.Operator.API.Responses;
using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.Interfaces.Bal;
using LLM.Store.ApplicationCore.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Goggly_Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationMasterController : ControllerBase
    {
        private readonly IStationMasterRepo _StationMasterRepo;
        public StationMasterController(IStationMasterRepo StationMasterRepo)
        {
            _StationMasterRepo = StationMasterRepo;
        }

        [HttpPost("CreateStationMaster")]
        public async Task<IActionResult> CreateStationMaster([FromQuery]  Token TokenInfo, CreateStationMasterRequest entity)
        {
            ISingleModelResponse<CreateStationMasterResponse> response = new SingleModelResponse<CreateStationMasterResponse>();
            try
            {
        
                CreateStationMasterResponse ResponseViewModel = await _StationMasterRepo.CreateStationMaster(entity,TokenInfo);

                if ( ResponseViewModel.station_code != "Station Code Already Exists")
                {
                    response.Model = ResponseViewModel;
                    response.Message = "SuccesfullyCreated";

                }
                else
                {
                    response.IsError = true;
                    response.Model = ResponseViewModel;
                    response.Message = "Invalid";
                }

                return Ok(response);
            }

            catch (Exception ex)
            {
                response.IsError = true;
                response.ErrorMessage = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpPut("UpdateStationMaster")]  
        public async Task<IActionResult> UpdateStationMaster(UpdateStationMasterRequest entity)
        {
            ISingleModelResponse<UpdateStationMasterResponse> response = new SingleModelResponse<UpdateStationMasterResponse>();
            try
            {

                UpdateStationMasterResponse ResponseViewModel = await _StationMasterRepo.UpdateStationMaster(entity);

                if (ResponseViewModel.station_code != null && ResponseViewModel.msg== "Updated.")
                {
                    response.Model = ResponseViewModel;
                    response.Message = "SuccesfullyUpdated!";
                }
                else
                {
                    response.IsError = true;
                    response.Model = ResponseViewModel;
                    response.Message = "Invalid";
                }

                return Ok(response);
            }

            catch (Exception ex)
            {
                response.IsError = true;
                response.ErrorMessage = ex.Message;
                return BadRequest(response);
            }

        }
       
        [HttpGet("DetailStationMaster")]
        public async Task<IActionResult> GetDetailsStationMaster(string station_code)
        {
            ISingleModelResponse<DetailStationMasterResponse> response = new SingleModelResponse<DetailStationMasterResponse>();
            try
            {

                DetailStationMasterResponse result = await _StationMasterRepo.GetDetailsStationMaster(station_code);
                if (result.station_code != null && result.msg == "Data Matched")
                {
                    response.Model = result;
                    response.Message = "Station Detail Found!";
                }
                else
                {
                    response.IsError = true;
                    response.Message = "Station Detail Not Found.";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.ErrorMessage = ex.Message;
                return BadRequest(response);
            }
        }


        [HttpPost("ListStationMaster")]
        public async Task<IActionResult> ListStationMaster([FromQuery] int pageIndex, int pageSize, ListStationMasterRequest entity)
        {
            IListModelResponse<ListStationMasterResponse> response = new ListModelResponse<ListStationMasterResponse>();
            try
            {
                (int total, List<ListStationMasterResponse> result) = await _StationMasterRepo.ListStationMaster(pageIndex,pageSize, entity);
                if (total > 0 && result != null)
                {
                    response.Model = result;
                    response.TotalRecord = total;
                    response.Message = "Sucessfully";
                }
                else
                {
                    response.IsError = true;
                    response.TotalRecord = 0;
                    response.Message = "No Data Found.";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.ErrorMessage = ex.Message;
                return BadRequest(response);
            }
        }
    }
}
