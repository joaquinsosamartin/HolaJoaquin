export interface IMapper<TIn, TOut> {
    map(source: TIn): TOut;
}
