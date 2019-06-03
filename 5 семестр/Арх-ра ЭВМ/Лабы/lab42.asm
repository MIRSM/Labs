stseg	segment	para	stack
	dw	16	dup(?)
stseg	ends
dseg	segment	para
mass	dw	10,12,2,4,-1,7,6,8
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
	push	mass[si]
	call	cproc
	cmp	y,255
	jge	final
	add	si,2
	loop	cycl
	mov	y,00
final:
	mov	ax,4C00h
	int	21h
	main	endp
cproc	proc	near
	push	bp
	mov	bp,sp
	mov	ax,[bp+4]
	cmp	ax,0
	jle	mz
cont:
	mov	sp,bp
	pop	bp
	mov	ax,0
	ret
mz:
	mov	y,255
	jmp	cont
	cproc	endp
cseg	ends
	end	main