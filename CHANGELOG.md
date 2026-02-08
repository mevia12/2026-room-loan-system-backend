# Changelog

Semua perubahan penting pada **Room Loan Backend API** akan dicatat di file ini.

Format changelog mengikuti konsep _Keep a Changelog_ dan _Semantic Versioning_ secara sederhana.

---

## [Unreleased]

- (belum ada)

---

## [1.0.0] - 2026-02-08

### Added

- Implementasi CRUD peminjaman ruangan
- Endpoint untuk:
  - Menambah peminjaman
  - Melihat daftar peminjaman
  - Melihat detail peminjaman
  - Menghapus peminjaman
- Pengelolaan status peminjaman:
  - Pending
  - Approved
  - Rejected
- Validasi input backend:
  - Field wajib (RoomName, BorrowerName, StartTime, EndTime)
  - Validasi EndTime harus lebih besar dari StartTime
  - Validasi status peminjaman
- Dokumentasi backend melalui README.md
- Integrasi Swagger untuk pengujian API

### Changed

- Struktur folder backend dirapikan sesuai standar ASP.NET Core Web API

### Notes

- Versi awal backend siap untuk diintegrasikan dengan frontend.
