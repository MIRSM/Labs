dseg	segment	para
string	db 50 dup("$")
dseg ends

cseg	segment	para
lab51	proc	near
; ввод строки до ENTER
enterch:
        assume	cs:cseg,ds:dseg
		mov	ax,dseg
		mov	ds,ax
		mov     dl, '>'
        mov     ah, 02h
        int     21h
        mov     cx, 50
        mov     bx, offset string
ech:
        mov     ah, 01h
        int     21h 
        cmp al,13
        jle quit
        mov     byte ptr [bx],al
        inc     bx
        loop    ech
quit:
	call	prn
        ret
	lab51 endp

prn proc near
 mov ax,dseg
 mov ds,ax
 mov dx,offset string 
 mov ah,09h
 int 21h
 mov ah,04Ch
 mov al,1h
int 21h
prn endp
cseg	ends
	end	lab51