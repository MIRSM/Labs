code        segment
 prog        proc    far
        assume cs:code, ds:code
        org     100h
	begin:
	mov ax,cs
	mov ds,ax
	mov cx,6

	; установка видеорежима 
	mov ah, 0 
	mov al, 10H 
	int 10h 
mov bl,1
	lea si,nme
; ввод символов
nloop:
	;вывод символа
	mov ah,0eH
	mov al,[si]
	
	int 10h
	inc	si
	inc bl
	loop nloop

mov	ah,02H
mov bh,0
mov dh,1
mov dl,0
int 10h

mov cx,9
	lea si,fml
floop:
	mov ah,0eH
	mov	al,[si]
	int 10h
	inc si
	inc bl
	loop floop
; выход из программы 
	exit: 
	mov ah, 4ch 
	int 21h 

nme db 'Dmitry'
fml db	'Ugrovatov'
;crlf db 0ah, 0dh, '$' 
prog endp
code        ends
end begin