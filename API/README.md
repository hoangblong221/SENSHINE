### Cách gọi để lấy dữ liệu theo ROLE

Các policy của các ROLE: RequireCEO, RequireManager, RequireReceptions, RequireStaff
```csharp

[HttpGet("ceo")]
[Authorize(Policy = "RequireCEO")]
public IActionResult GetCEOData()
{
    // Code để lấy dữ liệu chỉ dành cho CEO
    return Ok(new { Message = "This data is only accessible to CEO." });
}

[HttpGet("manager")]
[Authorize(Policy = "RequireManager")]
public IActionResult GetManagerData()
{
    // Code để lấy dữ liệu chỉ dành cho Manager
    return Ok(new { Message = "This data is only accessible to Managers." });
}
```
Các ROLE còn lại tương tự
.....
