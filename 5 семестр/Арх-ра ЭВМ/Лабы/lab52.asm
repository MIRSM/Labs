dseg	segment	para
dseg ends
cseg	segment	para
lab51	proc	near
    assume	cs:cseg,ds:dseg
	mov	ax,dseg
	mov	ds,ax
	mov	cx,50
wloop:
	mov	ax,0000h
	int 16h
	cmp	ah,01h
	jle	final
	loop wloop
final:
	mov	ah,04Ch
	int	21h
	ret
lab51   endp
cseg	ends
	end	lab51