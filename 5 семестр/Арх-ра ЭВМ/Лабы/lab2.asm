stseg	segment	para	stack
	dw	16	dup(?)
stseg	ends
dseg	segment	para
a	dw	10
b	dw	-6
c	dw	17
y	dw	?
dseg	ends
cseg	segment	para
lab2	proc	far
	assume	cs:cseg,ds:dseg,ss:stseg
	push	ds
	mov	ax,0
	push	ax
	mov	ax,dseg
	mov	ds,ax
	mov	ax,[b-2]
	sub	ax,[b+0]
	mov	bx,[b+2]
	add	ax,bx
	sub	ax,45
	mov	y,bx
	ret
lab2	endp
cseg	ends
	end	lab2