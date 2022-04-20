## Teddy Hotel
### ความเป็นมาของโปรแกรม
    ในปัจจุบันมีการจัดการข้อมูลห้องพักที่ยุ่งยาก และใช้งานยาก เลยอยากจะทำโปรแกรมที่ง่ายสะดวก 

<br/><br/>
### วัตถุประสงค์ของโปรแกรม
1.เพื่อให้สะดวกต่อการใช้งาน
2.สามารถจัดการข้อมูลห้องพักได้อย่างมีประสิทธิภาพ
3.อยากศึกษา

<br/><br/>
### โครงสร้างของโปรแกรม
```mermaid
classDiagram
    Program <|-- HomePage
    HomePage <|-- MainPage
    MainPage <|-- Bill
    Program : +Main()
    class HomePage{
        +Teddyhotel_Click()
        +buttonExit_Click()
    }
    class MainPage{
        +openToolStripMenuItem_Click()
        +saveToolStripMenuItem_Click()
        +buttonCheck_Click()
        +printDocument1_PrintPage()
        +buttonBill_Click()
        +buttonClear_Click()
        +button1savedata_Click()
    }
    class Bill{
        +showbill()
    }
  
```
<br/><br/>
### ผู้พัฒนาโปรแกรม
นางสาวณัฐธิดา บุญพา 643450647-2
