code        segment
 prog        proc    far
        assume cs:code, ds:code
        org     100h
	begin:
	mov ax,cs
	mov ds,ax
	mov cx,53

	; установка видеорежима 
	mov ah, 0 
	mov al, 0fh 
	int 10h 

; ввод символов
wloop:
	mov	ax,0000h
	int 16h
	cmp	ah,01h
	je	exit
	;вывод символа
	mov ah,0eH
	mov bl,5
	int 10h
	loop wloop

; выход из программы 
	exit: 
	mov ah, 4ch 
	int 21h 

prog endp
code        ends
end begin