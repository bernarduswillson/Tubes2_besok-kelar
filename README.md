# Pengaplikasian Algoritma BFS dan DFS dalam Menyelesaikan Persoalan Maze Treasure Hunt - STRATEGI ALGORITMA

## Anggota Kelompok
<table>
    <tr>
        <td colspan="3", align = "center"><center>Nama Kelompok: BesokKelar</center></td>
    </tr>
    <tr>
        <td>No.</td>
        <td>Nama</td>
        <td>NIM</td>
    </tr>
    <tr>
        <td>1.</td>
        <td>Henry Anand Septian Radityo</td>
        <td>13521004</td>
    </tr>
    <tr>
        <td>2.</td>
        <td>Bernardus Willson</td>
        <td>13521021</td>
    </tr>
    <tr>
        <td>3.</td>
        <td>Kenny Benaya Nathan</td>
        <td>13521023</td>
</table>

## Table of Contents
* [Deskripsi Singkat](#deskripsi-singkat)
* [Struktur File](#struktur-file)
* [Requirements](#requirements)
* [Cara Menjalankan Program](#cara-menjalankan-program)

## Deskripsi Singkat 
Dalam Tugas ini diberikan deskripsi permasalahan mengenai cara menemukan jalur untuk mengambil semua treasure yang terdapat pada suatu maze. Algoritma pencarian yang digunakan untuk menemukan jalur tersebut adalah Breadth First Search dan Depth First Search.

BFS (Breadth-First Search) adalah algoritma yang mencari jalan keluar dari labirin dengan menjelajahi semua kemungkinan langkah di level yang sama sebelum pindah ke level berikutnya. Dalam implementasinya, BFS menggunakan struktur data baris untuk menyimpan node yang belum diperiksa, sehingga BFS dapat memeriksa node secara sistematis dan menjamin untuk menemukan solusi terpendek.  

DFS (Depth-First Search) adalah algoritma yang menemukan jalan keluar dari labirin dengan menjelajahi setiap cabang sampai ke jalan buntu, kemudian kembali ke node sebelumnya dan menjelajahi cabang lainnya. Dalam sebuah aplikasi, DFS menggunakan struktur data tumpukan untuk menyimpan node yang tidak diperiksa, sehingga DFS dapat menjelajahi node secara sistematis, tetapi tidak dijamin untuk menemukan solusi terpendek. 

Keuntungan BFS adalah menjamin  solusi terpendek karena  memeriksa semua kemungkinan pergerakan pada level yang sama sebelum pindah ke level berikutnya. Namun kerugiannya adalah jika solusinya jauh dari node aslinya, membutuhkan banyak memori dan waktu eksekusi yang lebih lama. Di sisi lain, keuntungan dari DFS adalah membutuhkan lebih sedikit memori dan biasanya lebih cepat daripada BFS untuk menemukan solusi yang lebih dekat ke node awal. Namun, sisi negatifnya adalah tidak dijamin untuk menemukan solusi terpendek dan dapat berputar jika tidak diterapkan dengan benar. Dikarenakan kelebihan dan kekurangan  masing-masing algoritma,  pemilihan algoritma BFS atau DFS tergantung pada karakteristik masalah dan tujuan pencarian yang ingin dicapai. Jika Anda ingin mencari solusi terpendek,  BFS lebih disarankan. Namun, jika Anda ingin mencari solusi dengan cepat dan solusinya tidak terlalu jauh, disarankan untuk menggunakan algoritma DFS, karena pencarian  DFS tidak memeriksa node sebanyak  BFS.

## Struktur File
```bash
📦Tubes2_besok-kelar
 ┣ 📂bin
 ┃ ┗ 📜setup.zip
 ┣ 📂test
 ┃ ┗ 📜sampel-1.exe
 ┃ ┗ 📜sampel-2.exe
 ┃ ┗ 📜sampel-3.exe
 ┃ ┗ 📜sampel-4.exe
 ┃ ┗ 📜sampel-5.exe
 ┣ 📂doc
 ┃ ┣ 📜besok-kelar.pdf
 ┣ 📂src
 ┃ ┣ 📂bin
 ┃ ┣ ┣ 📂debug
 ┃ ┣ ┣ ┣ 📂net7.0-windows
 ┃ ┣ 📂obj
 ┃ ┣ 📂properties
 ┃ ┣ ┣ 📜Resources.Designer.cs
 ┃ ┣ ┣ 📜Resources.resx
 ┗ 📜README.md
 ```
 
 ## Requirements
 1. .NET Framework & .NET Core Runtime
 2. IDE (Disarankan menggunakan Visual Studio)
 3. Compiler .NET Framework atau .NET Core SDK
 
 ## Cara Menjalankan Program
 ### Compile
 1. Clone repository Github ini
 2. Install semua requirements yang diperlukan
 3. Jalankan program dengan mengetikkan `dotnet run` di terminal pada directory repository ini
 ### Tanpa Compile
 1. Clone repository Github ini
 2. Install semua requirements yang diperlukan
 3. Jalankan program dengan menjalankan `setup.exe` pada direktori bin
 
