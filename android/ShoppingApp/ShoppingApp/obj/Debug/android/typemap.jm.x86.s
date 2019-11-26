	/* Data SHA1: 0f8aa7c7a78cb2b3809f8c6b9e97b6b47fa27c85 */
	.file	"typemap.jm.inc"

	/* Mapping header */
	.section	.data.jm_typemap,"aw",@progbits
	.type	jm_typemap_header, @object
	.p2align	2
	.global	jm_typemap_header
jm_typemap_header:
	/* version */
	.long	1
	/* entry-count */
	.long	1171
	/* entry-length */
	.long	262
	/* value-offset */
	.long	117
	.size	jm_typemap_header, 16

	/* Mapping data */
	.type	jm_typemap, @object
	.global	jm_typemap
jm_typemap:
	.size	jm_typemap, 306803
	.include	"typemap.jm.inc"
