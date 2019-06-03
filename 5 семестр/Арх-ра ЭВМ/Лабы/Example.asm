data segment
   ;=======================================================
   ; начало -> форматы представления данных
   ;========================================================
   ; bit processor=8
   ; integer  a=26; b=-24
   a db 01ah
   b db -18h
   ;  pro_fract   c=0,26; d=0,24; e=-0,24
   c db 21h
   d db 1eh
   e db 0e2h
   ; -------------------------------
   ; bit processor=16
   ; integer a1=26; b1=-24
   a1 dw 01ah
   b1 dw -18h
   ; pro_fract c1=0,26; d1=0,24; e1=-0,24
   c1 dw 2147h
   d1 dw 1eb8h
   e1 dw 0e148h
   ; impro_fr = 24,26; -26,24
   f dw 1842h
   g dw 0e5c3h
   ; real (IEEE 754) r=24,26
   r1 db 7ah    ; most significant byte
   r2 db 14h
   r3 db 0c2h
   r4 db 41h
   ; real (IEEE 754) x=-24,26
   x1 db 7ah    ; most significant byte
   x2 db 14h
   x3 db 0c2h
   x4 db 0c1h
   ;=======================================================
   ; конец -> форматы представления данных
   ;========================================================
data ends
code segment
assume cs:code, ds:data, ss:nothing
   start: 	mov ax, data ;load adress
   		mov ds, ax ; data segment
   ;=======================================================
   ; начало -> сложение/вычитание с фиксированной точкой
   ;========================================================
   ; bit processor=8 (integer)
	mov ah, a
	mov bh, b
	add ah, bh    ; a+b
	;------------------------
	mov a, ah
                sub ah, bh    ; a-b
                ;------------------------
                mov ah, a
                neg ah
                add ah, bh    ; -a+b
                ;------------------------
                mov ah, a
                neg ah
                sub ah, bh    ; -a-b
                ;------------------------
  ; bit processor=8 (proper fraction)
                mov ah, c
	mov bh, e
	add ah, bh    ; c+e
	;------------------------
                mov ah, c
                sub ah, bh    ; c-e
                ;------------------------
                mov ah, c
                neg ah
                add ah, bh    ; -c+e
                ;------------------------
                mov ah, c
                neg ah
                sub ah, bh    ; -c-e
                ;------------------------
   ; bit processor=16   (integer)
 	mov ax, a1
	mov bx, b1
	add ax, bx    ; a1+b1
	;------------------------
	mov ax, a1
                sub ax, bx    ; a1-b1
                ;------------------------
                mov ax, a1
                neg ax
                add ax, bx    ; -a1+b1
                ;------------------------
                mov ax, a1
                neg ax
                sub ax, bx    ; -a1-b1
                ;------------------------
   ; bit processor=16   (proper fraction)
 	mov ax, a1
	mov bx, b1
	add ax, bx    ; c1+e1
	;------------------------
		mov ax, a1
                sub ax, bx    ; c1-e1
                ;------------------------
                mov ax, a1
                neg ax
                add ax, bx    ; -c1+e1
                ;------------------------
                mov ax, a1
                neg ax
                sub ax, bx    ; -c1-e1
                ;------------------------
    ; bit processor=16   (improper fraction)
 	mov ax, f
	mov bx, g
	add ax, bx    ; c1+e1
	;------------------------
	mov ax, f
                sub ax, bx    ; c1-e1
                ;------------------------
                mov ax, f
                neg ax
                add ax, bx    ; -c1+e1
                ;------------------------
                mov ax, f
                neg ax
                sub ax, bx    ; -c1-e1
                ;------------------------
   ;=======================================================
   ; конец -> сложение/вычитание с фиксированной точкой
   ;========================================================
   quit:	mov ax, 4c00h ; cod to finish 0
   		int 21 ; exit to dos
code ends
end start
