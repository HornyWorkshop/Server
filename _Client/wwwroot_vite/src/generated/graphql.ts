import gql from 'graphql-tag';
import * as VueApolloComposable from '@vue/apollo-composable';
import * as VueCompositionApi from 'vue';
export type Maybe<T> = T | null;
export type Exact<T extends { [key: string]: unknown }> = { [K in keyof T]: T[K] };
export type MakeOptional<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]?: Maybe<T[SubKey]> };
export type MakeMaybe<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]: Maybe<T[SubKey]> };
export type ReactiveFunction<TParam> = () => TParam;
/** All built-in and custom scalars, mapped to their actual values */
export type Scalars = {
  ID: string;
  String: string;
  Boolean: boolean;
  Int: number;
  Float: number;
  /** The `Byte` scalar type represents non-fractional whole numeric values. Byte can represent values between 0 and 255. */
  Byte: any;
};

export type CardModel = {
  readonly checksum?: Maybe<ReadonlyArray<Scalars['Byte']>>;
  readonly id: Scalars['Int'];
  readonly name: LocaleModel;
  readonly url?: Maybe<Scalars['String']>;
};

/** A connection to a list of items. */
export type CategoriesConnection = {
  /** A list of edges. */
  readonly edges?: Maybe<ReadonlyArray<CategoriesEdge>>;
  /** A flattened list of the nodes. */
  readonly nodes?: Maybe<ReadonlyArray<CategoryModel>>;
  /** Information to aid in pagination. */
  readonly pageInfo: PageInfo;
  readonly totalCount: Scalars['Int'];
};

/** An edge in a connection. */
export type CategoriesEdge = {
  /** A cursor for use in pagination. */
  readonly cursor: Scalars['String'];
  /** The item at the end of the edge. */
  readonly node: CategoryModel;
};

export type CategoryModel = {
  readonly franchises: ReadonlyArray<FranchiseModel>;
  readonly id: Scalars['Int'];
  readonly name: LocaleModel;
  readonly persons: ReadonlyArray<PersonModel>;
};

export type CategoryModelFilterInput = {
  readonly and?: Maybe<ReadonlyArray<CategoryModelFilterInput>>;
  readonly franchises?: Maybe<ListFilterInputTypeOfFranchiseModelFilterInput>;
  readonly id?: Maybe<ComparableInt32OperationFilterInput>;
  readonly name?: Maybe<LocaleModelFilterInput>;
  readonly or?: Maybe<ReadonlyArray<CategoryModelFilterInput>>;
  readonly persons?: Maybe<ListFilterInputTypeOfPersonModelFilterInput>;
};

export type CategoryModelSortInput = {
  readonly id?: Maybe<SortEnumType>;
  readonly name?: Maybe<LocaleModelSortInput>;
};

export type ComparableInt32OperationFilterInput = {
  readonly eq?: Maybe<Scalars['Int']>;
  readonly gt?: Maybe<Scalars['Int']>;
  readonly gte?: Maybe<Scalars['Int']>;
  readonly in?: Maybe<ReadonlyArray<Scalars['Int']>>;
  readonly lt?: Maybe<Scalars['Int']>;
  readonly lte?: Maybe<Scalars['Int']>;
  readonly neq?: Maybe<Scalars['Int']>;
  readonly ngt?: Maybe<Scalars['Int']>;
  readonly ngte?: Maybe<Scalars['Int']>;
  readonly nin?: Maybe<ReadonlyArray<Scalars['Int']>>;
  readonly nlt?: Maybe<Scalars['Int']>;
  readonly nlte?: Maybe<Scalars['Int']>;
};

export type CreateCardInput = {
  readonly file: Scalars['String'];
  readonly franchises: ReadonlyArray<Scalars['Int']>;
  readonly name: LocaleValueInput;
  readonly tags: ReadonlyArray<Scalars['Int']>;
};

export type CreateCategoryInput = {
  readonly name: LocaleValueInput;
};

export type CreateFranchiseInput = {
  readonly name: LocaleValueInput;
  readonly tags: ReadonlyArray<Scalars['Int']>;
};

export type CreateTagInput = {
  readonly name: LocaleValueInput;
};

export type FranchiseModel = {
  readonly categories: ReadonlyArray<CategoryModel>;
  readonly id: Scalars['Int'];
  readonly name: LocaleModel;
  readonly tags: ReadonlyArray<TagModel>;
};

export type FranchiseModelFilterInput = {
  readonly and?: Maybe<ReadonlyArray<FranchiseModelFilterInput>>;
  readonly categories?: Maybe<ListFilterInputTypeOfCategoryModelFilterInput>;
  readonly id?: Maybe<ComparableInt32OperationFilterInput>;
  readonly name?: Maybe<LocaleModelFilterInput>;
  readonly or?: Maybe<ReadonlyArray<FranchiseModelFilterInput>>;
  readonly tags?: Maybe<ListFilterInputTypeOfTagModelFilterInput>;
};

export type FranchiseModelSortInput = {
  readonly id?: Maybe<SortEnumType>;
  readonly name?: Maybe<LocaleModelSortInput>;
};

/** A connection to a list of items. */
export type FranchisesConnection = {
  /** A list of edges. */
  readonly edges?: Maybe<ReadonlyArray<FranchisesEdge>>;
  /** A flattened list of the nodes. */
  readonly nodes?: Maybe<ReadonlyArray<FranchiseModel>>;
  /** Information to aid in pagination. */
  readonly pageInfo: PageInfo;
  readonly totalCount: Scalars['Int'];
};

/** An edge in a connection. */
export type FranchisesEdge = {
  /** A cursor for use in pagination. */
  readonly cursor: Scalars['String'];
  /** The item at the end of the edge. */
  readonly node: FranchiseModel;
};

export type ListFilterInputTypeOfCategoryModelFilterInput = {
  readonly all?: Maybe<CategoryModelFilterInput>;
  readonly any?: Maybe<Scalars['Boolean']>;
  readonly none?: Maybe<CategoryModelFilterInput>;
  readonly some?: Maybe<CategoryModelFilterInput>;
};

export type ListFilterInputTypeOfFranchiseModelFilterInput = {
  readonly all?: Maybe<FranchiseModelFilterInput>;
  readonly any?: Maybe<Scalars['Boolean']>;
  readonly none?: Maybe<FranchiseModelFilterInput>;
  readonly some?: Maybe<FranchiseModelFilterInput>;
};

export type ListFilterInputTypeOfPersonModelFilterInput = {
  readonly all?: Maybe<PersonModelFilterInput>;
  readonly any?: Maybe<Scalars['Boolean']>;
  readonly none?: Maybe<PersonModelFilterInput>;
  readonly some?: Maybe<PersonModelFilterInput>;
};

export type ListFilterInputTypeOfTagModelFilterInput = {
  readonly all?: Maybe<TagModelFilterInput>;
  readonly any?: Maybe<Scalars['Boolean']>;
  readonly none?: Maybe<TagModelFilterInput>;
  readonly some?: Maybe<TagModelFilterInput>;
};

export type LocaleModel = {
  readonly en: Scalars['String'];
  readonly franchises: ReadonlyArray<FranchiseModel>;
  readonly id: Scalars['Int'];
  readonly jp: Scalars['String'];
  readonly kr: Scalars['String'];
  readonly persons: ReadonlyArray<PersonModel>;
  readonly ru: Scalars['String'];
  readonly tags: ReadonlyArray<TagModel>;
};

export type LocaleModelFilterInput = {
  readonly and?: Maybe<ReadonlyArray<LocaleModelFilterInput>>;
  readonly en?: Maybe<StringOperationFilterInput>;
  readonly franchises?: Maybe<ListFilterInputTypeOfFranchiseModelFilterInput>;
  readonly id?: Maybe<ComparableInt32OperationFilterInput>;
  readonly jp?: Maybe<StringOperationFilterInput>;
  readonly kr?: Maybe<StringOperationFilterInput>;
  readonly or?: Maybe<ReadonlyArray<LocaleModelFilterInput>>;
  readonly persons?: Maybe<ListFilterInputTypeOfPersonModelFilterInput>;
  readonly ru?: Maybe<StringOperationFilterInput>;
  readonly tags?: Maybe<ListFilterInputTypeOfTagModelFilterInput>;
};

export type LocaleModelSortInput = {
  readonly en?: Maybe<SortEnumType>;
  readonly id?: Maybe<SortEnumType>;
  readonly jp?: Maybe<SortEnumType>;
  readonly kr?: Maybe<SortEnumType>;
  readonly ru?: Maybe<SortEnumType>;
};

export type LocaleValueInput = {
  readonly en: Scalars['String'];
  readonly jp: Scalars['String'];
  readonly kr: Scalars['String'];
  readonly ru: Scalars['String'];
};

export type Mutation = {
  readonly addCard: CardModel;
  readonly addCategory: CategoryModel;
  readonly addFranchise: FranchiseModel;
  readonly addTag: TagModel;
};


export type MutationAddCardArgs = {
  input: CreateCardInput;
};


export type MutationAddCategoryArgs = {
  input: CreateCategoryInput;
};


export type MutationAddFranchiseArgs = {
  input: CreateFranchiseInput;
};


export type MutationAddTagArgs = {
  input: CreateTagInput;
};

/** Information about pagination in a connection. */
export type PageInfo = {
  /** When paginating forwards, the cursor to continue. */
  readonly endCursor?: Maybe<Scalars['String']>;
  /** Indicates whether more edges exist following the set defined by the clients arguments. */
  readonly hasNextPage: Scalars['Boolean'];
  /** Indicates whether more edges exist prior the set defined by the clients arguments. */
  readonly hasPreviousPage: Scalars['Boolean'];
  /** When paginating backwards, the cursor to continue. */
  readonly startCursor?: Maybe<Scalars['String']>;
};

export type PersonModel = {
  readonly categories: ReadonlyArray<CategoryModel>;
  readonly franchises: ReadonlyArray<FranchiseModel>;
  readonly id: Scalars['Int'];
  readonly name: LocaleModel;
  readonly tags: ReadonlyArray<TagModel>;
};

export type PersonModelFilterInput = {
  readonly and?: Maybe<ReadonlyArray<PersonModelFilterInput>>;
  readonly categories?: Maybe<ListFilterInputTypeOfCategoryModelFilterInput>;
  readonly franchises?: Maybe<ListFilterInputTypeOfFranchiseModelFilterInput>;
  readonly id?: Maybe<ComparableInt32OperationFilterInput>;
  readonly name?: Maybe<LocaleModelFilterInput>;
  readonly or?: Maybe<ReadonlyArray<PersonModelFilterInput>>;
  readonly tags?: Maybe<ListFilterInputTypeOfTagModelFilterInput>;
};

export type Query = {
  readonly categories?: Maybe<CategoriesConnection>;
  readonly franchises?: Maybe<FranchisesConnection>;
  readonly tags?: Maybe<TagsConnection>;
};


export type QueryCategoriesArgs = {
  after?: Maybe<Scalars['String']>;
  before?: Maybe<Scalars['String']>;
  first?: Maybe<Scalars['Int']>;
  last?: Maybe<Scalars['Int']>;
  order?: Maybe<ReadonlyArray<CategoryModelSortInput>>;
  where?: Maybe<CategoryModelFilterInput>;
};


export type QueryFranchisesArgs = {
  after?: Maybe<Scalars['String']>;
  before?: Maybe<Scalars['String']>;
  first?: Maybe<Scalars['Int']>;
  last?: Maybe<Scalars['Int']>;
  order?: Maybe<ReadonlyArray<FranchiseModelSortInput>>;
  where?: Maybe<FranchiseModelFilterInput>;
};


export type QueryTagsArgs = {
  after?: Maybe<Scalars['String']>;
  before?: Maybe<Scalars['String']>;
  first?: Maybe<Scalars['Int']>;
  last?: Maybe<Scalars['Int']>;
  order?: Maybe<ReadonlyArray<TagModelSortInput>>;
  where?: Maybe<TagModelFilterInput>;
};

export const enum SortEnumType {
  Asc = 'ASC',
  Desc = 'DESC'
};

export type StringOperationFilterInput = {
  readonly and?: Maybe<ReadonlyArray<StringOperationFilterInput>>;
  readonly contains?: Maybe<Scalars['String']>;
  readonly endsWith?: Maybe<Scalars['String']>;
  readonly eq?: Maybe<Scalars['String']>;
  readonly in?: Maybe<ReadonlyArray<Maybe<Scalars['String']>>>;
  readonly ncontains?: Maybe<Scalars['String']>;
  readonly nendsWith?: Maybe<Scalars['String']>;
  readonly neq?: Maybe<Scalars['String']>;
  readonly nin?: Maybe<ReadonlyArray<Maybe<Scalars['String']>>>;
  readonly nstartsWith?: Maybe<Scalars['String']>;
  readonly or?: Maybe<ReadonlyArray<StringOperationFilterInput>>;
  readonly startsWith?: Maybe<Scalars['String']>;
};

export type TagModel = {
  readonly franchises: ReadonlyArray<FranchiseModel>;
  readonly id: Scalars['Int'];
  readonly name: LocaleModel;
  readonly persons: ReadonlyArray<PersonModel>;
};

export type TagModelFilterInput = {
  readonly and?: Maybe<ReadonlyArray<TagModelFilterInput>>;
  readonly franchises?: Maybe<ListFilterInputTypeOfFranchiseModelFilterInput>;
  readonly id?: Maybe<ComparableInt32OperationFilterInput>;
  readonly name?: Maybe<LocaleModelFilterInput>;
  readonly or?: Maybe<ReadonlyArray<TagModelFilterInput>>;
  readonly persons?: Maybe<ListFilterInputTypeOfPersonModelFilterInput>;
};

export type TagModelSortInput = {
  readonly id?: Maybe<SortEnumType>;
  readonly name?: Maybe<LocaleModelSortInput>;
};

/** A connection to a list of items. */
export type TagsConnection = {
  /** A list of edges. */
  readonly edges?: Maybe<ReadonlyArray<TagsEdge>>;
  /** A flattened list of the nodes. */
  readonly nodes?: Maybe<ReadonlyArray<TagModel>>;
  /** Information to aid in pagination. */
  readonly pageInfo: PageInfo;
  readonly totalCount: Scalars['Int'];
};

/** An edge in a connection. */
export type TagsEdge = {
  /** A cursor for use in pagination. */
  readonly cursor: Scalars['String'];
  /** The item at the end of the edge. */
  readonly node: TagModel;
};

export type CategoriesQueryVariables = Exact<{ [key: string]: never; }>;


export type CategoriesQuery = { readonly categories?: Maybe<{ readonly nodes?: Maybe<ReadonlyArray<{ readonly id: number, readonly name: { readonly id: number, readonly ru: string, readonly en: string, readonly kr: string, readonly jp: string } }>> }> };

export type FranchisesQueryVariables = Exact<{
  first: Scalars['Int'];
  after?: Maybe<Scalars['String']>;
}>;


export type FranchisesQuery = { readonly franchises?: Maybe<{ readonly nodes?: Maybe<ReadonlyArray<{ readonly id: number, readonly name: { readonly id: number, readonly ru: string, readonly en: string, readonly kr: string, readonly jp: string }, readonly categories: ReadonlyArray<{ readonly id: number, readonly name: { readonly id: number, readonly ru: string, readonly en: string, readonly kr: string, readonly jp: string } }>, readonly tags: ReadonlyArray<{ readonly id: number, readonly name: { readonly id: number, readonly ru: string, readonly en: string, readonly kr: string, readonly jp: string } }> }>> }> };

export type TagsQueryVariables = Exact<{ [key: string]: never; }>;


export type TagsQuery = { readonly tags?: Maybe<{ readonly nodes?: Maybe<ReadonlyArray<{ readonly id: number, readonly name: { readonly id: number, readonly ru: string, readonly en: string, readonly kr: string, readonly jp: string } }>> }> };


export const CategoriesDocument = gql`
    query Categories {
  categories {
    nodes {
      id
      name {
        id
        ru
        en
        kr
        jp
      }
    }
  }
}
    `;

/**
 * __useCategoriesQuery__
 *
 * To run a query within a Vue component, call `useCategoriesQuery` and pass it any options that fit your needs.
 * When your component renders, `useCategoriesQuery` returns an object from Apollo Client that contains result, loading and error properties
 * you can use to render your UI.
 *
 * @param options that will be passed into the query, supported options are listed on: https://v4.apollo.vuejs.org/guide-composable/query.html#options;
 *
 * @example
 * const { result, loading, error } = useCategoriesQuery();
 */
export function useCategoriesQuery(options: VueApolloComposable.UseQueryOptions<CategoriesQuery, CategoriesQueryVariables> | VueCompositionApi.Ref<VueApolloComposable.UseQueryOptions<CategoriesQuery, CategoriesQueryVariables>> | ReactiveFunction<VueApolloComposable.UseQueryOptions<CategoriesQuery, CategoriesQueryVariables>> = {}) {
  return VueApolloComposable.useQuery<CategoriesQuery, CategoriesQueryVariables>(CategoriesDocument, {}, options);
}
export type CategoriesQueryCompositionFunctionResult = VueApolloComposable.UseQueryReturn<CategoriesQuery, CategoriesQueryVariables>;
export const FranchisesDocument = gql`
    query Franchises($first: Int!, $after: String = null) {
  franchises(first: $first, after: $after) {
    nodes {
      id
      name {
        id
        ru
        en
        kr
        jp
      }
      categories {
        id
        name {
          id
          ru
          en
          kr
          jp
        }
      }
      tags {
        id
        name {
          id
          ru
          en
          kr
          jp
        }
      }
    }
  }
}
    `;

/**
 * __useFranchisesQuery__
 *
 * To run a query within a Vue component, call `useFranchisesQuery` and pass it any options that fit your needs.
 * When your component renders, `useFranchisesQuery` returns an object from Apollo Client that contains result, loading and error properties
 * you can use to render your UI.
 *
 * @param variables that will be passed into the query
 * @param options that will be passed into the query, supported options are listed on: https://v4.apollo.vuejs.org/guide-composable/query.html#options;
 *
 * @example
 * const { result, loading, error } = useFranchisesQuery({
 *   first: // value for 'first'
 *   after: // value for 'after'
 * });
 */
export function useFranchisesQuery(variables: FranchisesQueryVariables | VueCompositionApi.Ref<FranchisesQueryVariables> | ReactiveFunction<FranchisesQueryVariables>, options: VueApolloComposable.UseQueryOptions<FranchisesQuery, FranchisesQueryVariables> | VueCompositionApi.Ref<VueApolloComposable.UseQueryOptions<FranchisesQuery, FranchisesQueryVariables>> | ReactiveFunction<VueApolloComposable.UseQueryOptions<FranchisesQuery, FranchisesQueryVariables>> = {}) {
  return VueApolloComposable.useQuery<FranchisesQuery, FranchisesQueryVariables>(FranchisesDocument, variables, options);
}
export type FranchisesQueryCompositionFunctionResult = VueApolloComposable.UseQueryReturn<FranchisesQuery, FranchisesQueryVariables>;
export const TagsDocument = gql`
    query Tags {
  tags {
    nodes {
      id
      name {
        id
        ru
        en
        kr
        jp
      }
    }
  }
}
    `;

/**
 * __useTagsQuery__
 *
 * To run a query within a Vue component, call `useTagsQuery` and pass it any options that fit your needs.
 * When your component renders, `useTagsQuery` returns an object from Apollo Client that contains result, loading and error properties
 * you can use to render your UI.
 *
 * @param options that will be passed into the query, supported options are listed on: https://v4.apollo.vuejs.org/guide-composable/query.html#options;
 *
 * @example
 * const { result, loading, error } = useTagsQuery();
 */
export function useTagsQuery(options: VueApolloComposable.UseQueryOptions<TagsQuery, TagsQueryVariables> | VueCompositionApi.Ref<VueApolloComposable.UseQueryOptions<TagsQuery, TagsQueryVariables>> | ReactiveFunction<VueApolloComposable.UseQueryOptions<TagsQuery, TagsQueryVariables>> = {}) {
  return VueApolloComposable.useQuery<TagsQuery, TagsQueryVariables>(TagsDocument, {}, options);
}
export type TagsQueryCompositionFunctionResult = VueApolloComposable.UseQueryReturn<TagsQuery, TagsQueryVariables>;