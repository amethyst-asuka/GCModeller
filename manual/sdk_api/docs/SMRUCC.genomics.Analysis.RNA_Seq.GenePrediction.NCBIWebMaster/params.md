﻿# params
_namespace: [SMRUCC.genomics.Analysis.RNA_Seq.GenePrediction.NCBIWebMaster](./index.md)_





### Methods

#### #ctor
```csharp
SMRUCC.genomics.Analysis.RNA_Seq.GenePrediction.NCBIWebMaster.params.#ctor(System.Int32,System.Int32)
```
The GeneMark family of gene finding programs has been used for prokaryotic genome annotation since 1995 
 when GeneMark contributed to launching the genomic era by providing automatic gene annotation of 
 complete genomes of Haemophilus influenza, Methanoccus jannaschii as well as Escherichia coli and Bacillus subtilis.
 In GeneMark.hmm, 1,3 the second generation of GeneMark, the DNA sequence Is interpreted as a realization 
 of the hidden semi-Markov model with genome specific parameters. Then the maximum likelihood parse of 
 the sequence into protein-coding And non-coding regions Is generated by an optimization algorithm. 
 Note that the genome specific parameters of the model are determined from the submitted DNA sequence 2,3.

|Parameter Name|Remarks|
|--------------|-------|
|gencode|
 11 (Bacteria, Archaea);
 4 (Mycoplasma/Spiroplasma)
 |
|topology|
 0 partial/circular;
 1 linear
 |


