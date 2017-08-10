using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class n_m_array :MonoBehaviour,iarray
{
	private int[] _n_array;
	private int[] _m_array;

	public n_m_array set (int n, int m, int max)
	{
		int[] array = new int[max];
		int[] n_array = new int[n];
		int[] m_array = new int[m];

		for (int i = 0; i < array.Length; i++)
			array [i] = i;

		for (int i = 0; i < n_array.Length; i++) {
			var n_tmp = array.Except (n_array).ToArray ();
			n_array [i] = n_tmp [UnityEngine.Random.Range (0, n_tmp.Length)];
		}

		for (int i = 0; i < m_array.Length; i++) {
			var m_tmp = array.Except (n_array).Except (m_array).ToArray ();
			m_array [i] = m_tmp [UnityEngine.Random.Range (0, m_tmp.Length)];
		}

		_n_array = n_array;
		_m_array = m_array;

		return this;
	}

	public int[] n ()
	{
		return _n_array;
	}

	public int[] m ()
	{
		return _m_array;
	}

	public int[] n_m ()
	{
		return _n_array.Union (_m_array).ToArray ();
	}

	void Start ()
	{
//		iarray nm = gameObject.AddComponent<n_m_array> ().set (2, 3, 16);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}