using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using System.Runtime.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
// Add services to the container.
builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();
builder.Services.AddTransient<ISanPhamRepository, SanPhamRepository>();
builder.Services.AddTransient<ISanPhamBusiness, SanPhamBusiness>();
builder.Services.AddTransient<IKhachHangRepository, KhachHangRepository>();
builder.Services.AddTransient<IKhachHangBusiness, KhachHangBusiness>();
builder.Services.AddTransient<IHoaDonNhapRepository, HoaDonNhapRepository>();
builder.Services.AddTransient<IHoaDonNhapBusiness, HoaDonNhapBusiness>();
builder.Services.AddTransient<IDanhMucRepository, DanhMucRepository>();
builder.Services.AddTransient<IDanhMucBusiness, DanhMucBusiness>();
builder.Services.AddTransient<IThuongHieuRepository, ThuongHieuRepository>();
builder.Services.AddTransient<IThuongHieuBusiness, ThuongHieuBusiness>();
builder.Services.AddTransient<ITinhThanhPhoRepository, TinhThanhPhoRepository>();
builder.Services.AddTransient<ITinhThanhPhoBusiness, TinhThanhPhoBusiness>();
builder.Services.AddTransient<IDanhGiaRepository, DanhGiaRepository>();
builder.Services.AddTransient<IDanhGiaBusiness, DanhGiaBusiness>();
builder.Services.AddTransient<IGiamGiaRepository, GiamGiaRepository>();
builder.Services.AddTransient<IGiamGiaBusiness, GiamGiaBusiness>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
