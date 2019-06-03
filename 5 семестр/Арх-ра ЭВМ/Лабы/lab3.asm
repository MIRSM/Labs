stseg	segment	para	stack
	dw	16	dup(?)
stseg	ends
dseg	segment	para
mass	dw	10,12,-1,4,5,7,6,8
y	dw	0
dseg	ends
cseg	segment	para
lab3	proc	far
	assume	cs:cseg,ds:dseg,ss:stseg
	push	ds
	mov	ax,0
	push ax
	mov	ax,dseg
	mov	ds,ax
	mov	cx,8
	mov	si,0
cycl:	
	mov	ax,mass[si]
	cmp	ax,0
	jle	mz
	add	si,2
	loop	cycl
final:
	ret
mz:
	mov	y,255
	jmp	final
	lab3	endp
cseg	ends
	end	lab3
