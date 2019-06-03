stseg	segment	para	stack
	dw	16	dup(?)
stseg	ends
dseg	segment	para
mass	dw	10,12,2,4,5,7,6,8
y	dw	?
dseg	ends
cseg	segment	para
main	proc	near
	assume	cs:cseg,ds:dseg,ss:stseg
	push	ds
	mov	ax,0
	push	ax
	mov	ax,dseg
	mov	ds,ax
	mov	cx,8
	mov	si,0
cycl:
	mov	ax,mass[si]
	call	cproc
	cmp	y,255
	jge	final
	add	si,2
	loop	cycl
	mov	y,00
final:
	retf
	main	endp
mzproc	proc	near
	mov	y,255
	ret
	mzproc	endp
cproc	proc	near
	cmp	ax,0
	jle	mzproc
	ret
	cproc	endp
cseg	ends
	end	main