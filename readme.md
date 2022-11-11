# Note for Hệ thống thông tin thầy Jang



## A. Phần form + menubar list chức năng

![image-20221108145518280](./image/image-20221108145518280.png)



![image-20221108145605993](./image/image-20221108145605993.png)

![image-20221108145915956](./image/image-20221108145915956.png)

- cần thêm form của Lớp : do tài khoản lớp trưởng đăng nhập 

## I. Giao diện Lớp 

có các chức năng : 

|    tên chức năng     | Mô tả                                                        |
| :------------------: | ------------------------------------------------------------ |
|    Nhập danh sách    | Nhập danh sách đăng ký + gửi duyệt                           |
|    Đang chờ duyệt    | DS đang đợi duyệt ()                                         |
|       Đã duyệt       | DS đã được duyệt (tên cán bộ c,d duyệt)                      |
|        Đã hủy        | DS bị hủy (tên cán bộ c,d duyệt)                             |
| Thông tin thanh toán | Hiện các đợt thanh toán, danh sách thanh toán, tính năng tạo pdf in ds |



> Cần khăc phục ở danh sách : Mỗi học viên chỉ trên một dòng, thông tin chi tiết xem ở form khác.
>
> ![image-20221108150702501](./image/image-20221108150702501.png)



## II. Phần giao diện Đại Đội



- thêm chức năng ở menubar : **Danh sách chờ duyệt** (để duyệt ds lớp gửi lên) (xây dựng giống chức năng ở tiểu đoàn)

  ![image-20221108151232038](./image/image-20221108151232038.png)

  

ở danh sách thêm button để hủy theo từng học viên (học viên bị loại khỏi ds + thêm vào ds hủy + (có thể có nút undo))



- Phần **đăng ký cắt cơm**



![image-20221108142642761](./image/image-20221108142642761.png)

phần Đăng ký cắt cơm: **chọn** và **thêm** loại nghỉ (thêm vào **chi tiết loại nghỉ**)

Bổ sung csdl : chi tiết ra ngoài thêm **ngày nghỉ + ngày trả phép** 

![image-20221108142947538](./image/image-20221108142947538.png)

Phần danh sách sửa : Họ tên, lớp, Tên loại nghỉ, Chi tiết nghỉ (ấn vào hiện ra from mới), Xóa

Làm thêm chi tiết nghỉ : popup gồm : mã đăng ký, tên học viên,  ngày nghỉ, ngày trả phép.

- ra ngoài thêm ![image-20221108143616237](./image/image-20221108143616237.png) tickbox **cả ngày**

  ## III. Giao diện tiểu đoàn
  ![image](https://user-images.githubusercontent.com/97930158/201264293-f473fe37-3b5a-48cf-b51e-2201b33c95fc.png)
  - Thêm chức năng ở menubar: Thống kê số học viên cắt cơm và tiền cắt cơm
  - Cần thêm tiêu chuẩn tiền ăn của từng loại học viên, sửa ngày áp dụng và cập nhật tiền ăn mới, thêm chi tiết loại nghỉ có số bữa cố định như tranh thủ, nghỉ phép,...
